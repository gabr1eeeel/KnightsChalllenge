<template>
    <div v-if="knight">
        <v-card class="mx-auto" max-width="500">
            <v-card-title>
                <h1>Detalhes do Cavaleiro</h1>
            </v-card-title>
            <v-card-text>
                <v-row>
                    <v-col cols="12">
                        <p><b>Nome:</b> {{ knight.name }}</p>
                    </v-col>
                    <v-col cols="12">
                        <p><b>Apelido:</b> {{ knight.nickname }}</p>
                    </v-col>
                    <v-col cols="12">
                        <p><b>Aniversario:</b> {{ new Date(knight.birthday).toLocaleDateString('pt-BR') }}</p>
                    </v-col>
                    <v-col cols="12">
                        <p><b>Atributo Principal:</b> {{ knight.keyAttribute }}</p>
                    </v-col>
                    <v-col cols="12">
                        <p><b>Heroi:</b> {{ knight.isHero ? 'Sim' : 'Nao' }}</p>
                    </v-col>
                    <v-col cols="12">
                        <p><b>Idade:</b> {{ knight.age }}</p>
                    </v-col>
                    <v-col cols="12">
                        <p><b>Experiencia:</b> {{ knight.experience }}</p>
                    </v-col>
                    <v-col cols="12">
                        <p><b>Ataque:</b> {{ knight.attack }}</p>
                    </v-col>
                    <v-col cols="12">
                        <p><b>Quantidade de Armas:</b> {{ knight.weaponCount }}</p>
                    </v-col>
                    <v-col v-if="knight.weaponCount" cols="12">
                        <h3>Armas:</h3>
                        <v-list>
                            <v-list-item v-for="(weapon, index) in knight.weapons" :key="index">
                                <v-list-item-content>
                                    <v-list-item-title>{{ weapon.name }}</v-list-item-title>
                                    <v-list-item-subtitle>
                                        <b>Mod:</b> {{ weapon.mod }}, <b>Atributo:</b> {{ weapon.attr }}, <b>Equipado:</b> {{ weapon.equipped ? 'Sim' : 'Nao' }}
                                    </v-list-item-subtitle>
                                </v-list-item-content>
                            </v-list-item>
                        </v-list>
                    </v-col>
                    <v-col cols="12">
                        <h3>Atributos:</h3>
                        <v-list>
                            <v-list-item>
                                <v-list-item-content>
                                    <v-list-item-title><b>Forca:</b> {{ knight.attributes.strength }}</v-list-item-title>
                                </v-list-item-content>
                            </v-list-item>
                            <v-list-item>
                                <v-list-item-content>
                                    <v-list-item-title><b>Destreza:</b> {{ knight.attributes.dexterity }}</v-list-item-title>
                                </v-list-item-content>
                            </v-list-item>
                            <v-list-item>
                                <v-list-item-content>
                                    <v-list-item-title><b>Constituicao:</b> {{ knight.attributes.constitution }}</v-list-item-title>
                                </v-list-item-content>
                            </v-list-item>
                            <v-list-item>
                                <v-list-item-content>
                                    <v-list-item-title><b>Inteligencia:</b> {{ knight.attributes.intelligence }}</v-list-item-title>
                                </v-list-item-content>
                            </v-list-item>
                            <v-list-item>
                                <v-list-item-content>
                                    <v-list-item-title><b>Sabedoria:</b> {{ knight.attributes.wisdom }}</v-list-item-title>
                                </v-list-item-content>
                            </v-list-item>
                            <v-list-item>
                                <v-list-item-content>
                                    <v-list-item-title><b>Carisma:</b> {{ knight.attributes.charisma }}</v-list-item-title>
                                </v-list-item-content>
                            </v-list-item>
                        </v-list>
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
