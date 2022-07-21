import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import PageNotFound from '../views/PageNotFound.vue'
import SignUpView from '../views/SignUpView.vue'
import LoginView from '@/views/LoginView.vue'
import SearchCourseView from '@/views/SearchCourseView.vue'
import InstructorView from '@/views/InstructorView.vue'
import UserView from '@/views/UserView.vue'
import CoursePage from '@/views/CoursePage.vue'


const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/login',
    name: 'login',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/LoginView.vue')
  },
  {
    path: '/:catchAll(.*)*',
    name: "PageNotFound",
    component: PageNotFound
  },
  {
    path: '/signup',
    name: "SignUpView",
    component: SignUpView
  },
  {
    path: '/login',
    name: "LoginView",
    component: LoginView
  },
  {
    path: '/searchCourse',
    name: "SeachCourse",
    component: SearchCourseView
  }
  ,
  {
    path: '/user',
    name: "UserView",
    component: UserView
  }
  ,
  {
    path: '/instructor',
    name: "InstructorView",
    component: InstructorView
  },
  {
    path: '/course/:id',
    name: 'CoursePage',
    component: CoursePage,
  },
  {
    path: '/course',
    name: 'CoursePage1',
    component: CoursePage,
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
