import { createRouter, createWebHistory } from 'vue-router';
import Home from '@/components/Home.vue';
import ListKnights from '@/components/Knight/ListKnights.vue';
import ListHeroes from '@/components/Knight/ListHeroes.vue';
import CreateKnight from '@/components/Knight/CreateKnight.vue';
import EditKnight from '@/components/Knight/EditKnight.vue';
import KnightDetails from '@/components/Knight/KnightDetails.vue';

const routes = [
    { path: '/home', component: Home },
    { path: '/knights', component: ListKnights },
    { path: '/knights/heroes', component: ListHeroes },
    { path: '/create', component: CreateKnight },
    { path: '/edit/:id', component: EditKnight, props: true },
    { path: '/details/:id', component: KnightDetails, props: true },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;