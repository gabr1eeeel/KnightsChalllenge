<template>
    <v-app>
            <Navbar />

        <v-main>
            <v-container class="ma-4" fluid>
                <router-view />
            </v-container>
        </v-main>

        <v-footer app>
        </v-footer>
    </v-app>
</template>

<script>
    import Navbar from '@/components/Navbar.vue';

    export default {
        name: 'App',
        components: {
            Navbar
        }
    };
</script>

<style>

</style>