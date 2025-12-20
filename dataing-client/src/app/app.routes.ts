import { Routes } from '@angular/router';
import { MemberList } from '../features/members/member-list/member-list';
import { Messages } from '../features/messages/messages';
import { MemberDetails } from '../features/members/member-details/member-details';
import { Home } from '../features/home/home';
import { List } from '../features/list/list';
import { authGuard } from '../guards/auth-guard';

export const routes: Routes = [
  { path: '', component: Home }, // Home page accessible to everyone
  { path: 'home', component: Home }, // Alternative route for home
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      { path: 'members', component: MemberList }, // Added members list route
      { path: 'members/:id', component: MemberDetails },
      { path: 'messages', component: Messages },
      { path: 'lists', component: List },
    ]
  },
  { path: '**', redirectTo: 'home', pathMatch: 'full' } // Wildcard route for 404
];