<template>
    <v-card>
        <v-navigation-drawer
                             theme="dark"
                             permanent>
            <v-list nav>
                <v-list-item prepend-icon="mdi-home" to="/" title="Home" value="home"></v-list-item>
                <v-list-item prepend-icon="mdi-chess-knight" to="/knights" title="Cavaleiros" value="knights"></v-list-item>
                <v-list-item prepend-icon="mdi-trophy-award" to="/knights/heroes" title="Herois" value="heroes"></v-list-item>
            </v-list>
        </v-navigation-drawer>
    </v-card>
</template>

<script>
    export default {
        name: 'Navbar'
    }



</script>

<style scoped>
    nav ul {
        list-style: none;
        padding: 0;
    }

    nav li {
        display: inline;
        margin-right: 10px;
    }
</style>
