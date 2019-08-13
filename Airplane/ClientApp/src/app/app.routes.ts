import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AirplaneComponent } from './airplane/airplane.component';
import { AirplaneDetailComponent } from './airplane/airplane-detail/airplane-detail.component';


export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'airplanes', component: AirplaneComponent },
  { path: 'airplanes/:id', component: AirplaneDetailComponent },
  { path: 'airplane', component: AirplaneDetailComponent }

];

export const routing = RouterModule.forRoot(routes);
