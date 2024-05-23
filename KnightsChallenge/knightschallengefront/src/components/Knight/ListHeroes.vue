<template>
    <div>
        <h1>Lista de Herois</h1>
        <v-data-table :headers="headers"
                      :loading
                      :items="heroes"
                      item-key="id"
                      class="elevation-1 mt-4"
                      hide-default-footer>
            <template v-slot:item.action="{ item }">
            </template>
        </v-data-table>
    </div>
</template>

<script lang="ts">
    import { defineComponent, onMounted, ref } from 'vue';
    import knightService from '@/services/knightService';
    import type { Knight } from '@/types/Knight';

    export default defineComponent({
        name: 'ListHeroes',
        setup() {
            const loading = ref(true);
            const heroes = ref<Knight[]>([]);

            const headers = [
                { title: 'Nome', value: 'name' },
                { title: 'Idade(anos)', value: 'age' },
                { title: 'Armas', value: 'weapons.length' },
                { title: 'Atributo', value: 'keyAttribute' },
                { title: 'Ataque', value: 'attack' },
                { title: 'Exp', value: 'experience' }
            ]

            const fetchHeroes = async () => {
                heroes.value = await knightService.getHeroes();
                loading.value = false;
            };

            onMounted(fetchHeroes);

            return {
                heroes,
                headers,
                fetchHeroes,
                loading
            };
        },
    });
</script>
