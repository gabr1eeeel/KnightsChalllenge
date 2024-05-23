<template>
    <div>
        <h1>Editar Cavaleiro</h1>
        <div v-if="isLoading">Carregando...</div>
        <div v-else>
            <form @submit.prevent="updateKnight">
                <v-text-field v-model="knight!.name"
                              :counter="15"
                              disabled
                              label="Nome"></v-text-field>
                <v-text-field v-model="knight!.nickname"
                              :counter="15"
                              required
                              label="Apelido"></v-text-field>
                <router-link to="/knights">
                    <v-btn class="text-none mt-4 mr-4"
                           color="red"
                           variant="outlined"
                           rounded>
                        Voltar
                    </v-btn>
                </router-link>
                <v-btn class="text-none mt-4"
                       color="purple"
                       variant="outlined"
                       type="submit"
                       rounded>
                    Atualizar
                </v-btn>
            </form>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent, onMounted, ref } from 'vue';
    import { useRoute, useRouter } from 'vue-router';
    import knightService from '@/services/knightService';
    import type { Knight } from '@/types/Knight';

    export default defineComponent({
        name: 'EditKnight',
        setup() {
            const route = useRoute();
            const router = useRouter();
            const knight = ref<Knight | null>(null);
            const isLoading = ref(true);

            const fetchKnight = async () => {
                try {
                    const knightId = route.params.id as string;
                    knight.value = await knightService.getKnight(knightId);
                } catch (error) {
                    console.error('Erro ao carregar cavaleiro:', error);
                } finally {
                    isLoading.value = false;
                }
            };

            const updateKnight = async () => {
                if (knight.value) {
                    try {
                        await knightService.updateKnight(knight.value.id as string, knight.value);
                        router.push('/knights');
                    } catch (error) {
                        console.error('Erro ao atualizar cavaleiro:', error);
                    }
                } else {
                    console.error('Cavaleiro não carregado.');
                }
            };

            onMounted(fetchKnight);

            return {
                knight,
                isLoading,
                updateKnight,
            };
        },
    });
</script>