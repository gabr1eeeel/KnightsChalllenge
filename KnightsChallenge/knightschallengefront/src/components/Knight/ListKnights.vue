<template>
    <div>
        <h1>Lista de Cavaleiros</h1>
        <router-link to="/create">
            <v-btn class="text-none"
                   color="purple"
                   variant="outlined"
                   rounded>
                Adicionar Cavaleiro
            </v-btn>

        </router-link>
        <v-data-table :headers="headers"
                      :loading
                      :items="knights"
                      item-key="id"
                      class="elevation-1 mt-4"
                      hide-default-footer>
            <template v-slot:item.action="{ item }">
                <router-link :to="`/edit/${item.id}`">
                    <v-icon color="green" icon="mdi-pencil"></v-icon>
                </router-link>
                <router-link :to="`/details/${item.id}`">
                    <v-icon color="blue" icon="mdi-file-search-outline"></v-icon>
                </router-link>
                <a href="#" @click="deleteKnight(`${item.id}`)">
                    <v-icon color="red" icon="mdi-trash-can-outline"></v-icon>
                </a>
            </template>
        </v-data-table>
    </div>
</template>

<script lang="ts">
    import { defineComponent, onMounted, ref } from 'vue';
    import { useRouter } from 'vue-router';
    import knightService from '@/services/knightService';
    import type { Knight } from '@/types/Knight';

    export default defineComponent({
        name: 'ListKnights',
        setup() {
            const router = useRouter();
            const loading = ref(true);
            const knights = ref<Knight[]>([]);

            const headers = [
                { title: 'Nome', value: 'name' },
                { title: 'Idade(anos)', value: 'age' },
                { title: 'Armas', value: 'weapons.length' },
                { title: 'Atributo', value: 'keyAttribute' },
                { title: 'Ataque', value: 'attack' },
                { title: 'Exp', value: 'experience' },
                { title: 'Acoes', value: 'action', sortable: false },
            ]

            const fetchKnights = async () => {
                knights.value = await knightService.getKnights();
                loading.value = false;
            };

            const deleteKnight = async (id: string) => {
                await knightService.deleteKnight(id);
                router.push('/knights/heroes');
            };

            onMounted(fetchKnights);

            return {
                knights,
                headers,
                deleteKnight,
                loading
            };
        },
    });
</script>
