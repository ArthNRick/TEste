import HomePage from 'components/home-page'
import Users from 'components/users'
import User from 'components/user'
import NewUser from 'components/new-user'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'users', path: '/users', component: Users, display: 'Usuários', icon: 'users' },
  { name: 'user', path: '/user/:id', component: User, display: 'Usuário', icon: 'user', hidde:true },
  { name: 'new-user', path: '/new', component: NewUser, display: 'Novo usuário', icon: 'user', hidde:true }
]
