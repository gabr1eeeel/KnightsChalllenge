<template>
    <div>
        <h1>Criar Cavaleiro</h1>
        <form @submit.prevent="createKnight">
            <v-row>
                <v-col cols="12" sm="6" md="4">
                    <v-text-field v-model="knight.name" :counter="30" label="Nome" required></v-text-field>
                    <v-text-field v-model="knight.nickname" :counter="15" label="Apelido" required></v-text-field>
                    <v-text-field v-model="knight.birthday" type="date" :counter="15" label="Data Nascimento" required></v-text-field>
                </v-col>
            </v-row>

            <v-btn class="text-none ma-4" color="red" variant="outlined" rounded @click="removeWeapon">Remover Arma</v-btn>
            <v-btn class="text-none ma-4" color="green" variant="outlined" rounded @click="addWeapon">Adicionar Arma</v-btn>

            <v-row v-for="(weapon, index) in knight.weapons" :key="index">
                <v-col cols="12" sm="6" md="4">
                    <v-text-field v-model="weapon.name" label="Nome da Arma" required></v-text-field>
                    <v-text-field v-model.number="weapon.mod" label="Modificador da Arma" type="number"></v-text-field>
                    <v-autocomplete v-model="weapon.attr" :items="attributesWeapon" label="Atributo da Arma" required></v-autocomplete>
                    <v-checkbox v-model="weapon.equipped" label="Equipada"></v-checkbox>
                </v-col>
            </v-row>

            <v-row>
                <v-col cols="12">
                <h2>Dados</h2>
                </v-col>
                <v-col cols="12" sm="6" md="4" v-for="(value, attribute) in knight.attributes" :key="attribute">
                    <v-text-field v-model.number="knight.attributes[attribute]" :label="attribute" type="number"></v-text-field>
                </v-col>
            </v-row>

            <router-link to="/knights">
                <v-btn class="text-none mt-4 mr-4" color="red" variant="outlined" rounded>
                    Voltar
                </v-btn>
            </router-link>

            <v-btn class="text-none mt-4" color="purple" variant="outlined" type="submit" rounded>
                Adicionar
            </v-btn>
        </form>
    </div>
</template>

<script lang="ts">
    import { defineComponent, ref } from 'vue';
    import knightService from '@/services/knightService';
    import { useRoute, useRouter } from 'vue-router';
    import type { Knight } from '@/types/Knight';

    export default defineComponent({
        name: 'CreateKnight',
        setup() {
            const router = useRouter();
            const attributesWeapon = [
                "Strength",
                "Dexterity",
                "Constitution",
                "Intelligence",
                "Sisdom",
                "Charisma"
            ]
            const knight = ref<Knight>({
                name: '',
                nickname: '',
                birthday: '',
                weapons: [],
                attributes: {
                    strength: 0,
                    dexterity: 0,
                    constitution: 0,
                    intelligence: 0,
                    wisdom: 0,
                    charisma: 0,
                },
                keyAttribute: '',
                isHero: false,
            });

            const addWeapon = () => {
                knight.value.weapons.push({
                    name: '',
                    mod: 0,
                    attr: '',
                    equipped: false,
                });
            };

            const removeWeapon = () => {
                knight.value.weapons.pop();
            };

            const createKnight = async () => {
                await knightService.createKnight(knight.value);
                router.push('/knights');
            };

            return {
                knight,
                createKnight,
                attributesWeapon,
                addWeapon,
                removeWeapon
            };
        },
    });
</script>
<style>
    input[type='file'] {
        display: none
    }
</style>
