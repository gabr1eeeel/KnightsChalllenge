<template>
    <div v-if="knight">
        <v-card class="mx-auto" max-width="500">
            <v-card-title class="purple white--text">
                <span class="headline">Detalhes do Cavaleiro</span>
            </v-card-title>
            <v-card-text>
                <v-row v-for="(value, key) in knight" :key="key">
                    <v-col cols="12">
                        <p><b>{{ key }}</b>: {{ value }}</p>
                    </v-col>
                </v-row>
            </v-card-text>
            <v-card-actions>
                <router-link to="/knights">
                    <v-btn class="text-none mt-4 mr-4"
                           color="red"
                           variant="outlined"
                           rounded>
                        Voltar
                    </v-btn>
                </router-link>
            </v-card-actions>
        </v-card>
    </div>
</template>

<script lang="ts">
    import { defineComponent, onMounted, ref } from 'vue';
    import { useRoute } from 'vue-router';
    import knightService from '@/services/knightService';
    import type { Knight } from '@/types/Knight';

    export default defineComponent({
        name: 'KnightDetails',
        setup() {
            const route = useRoute();
            const knight = ref<Knight | null>(null);

            const fetchKnight = async () => {
                const knightId = route.params.id as string;
                knight.value = await knightService.getKnight(knightId);
            };

            onMounted(fetchKnight);

            return {
                knight,
            };
        },
    });
</script>

<style scoped>
</style>
