import { Component, OnInit } from '@angular/core';
import { IAirplane } from '../models/airplane.model';
import { AirplaneService } from './airplane.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-airplane',
  templateUrl: './airplane.component.html',
  styleUrls: ['./airplane.component.css']
})

export class AirplaneComponent implements OnInit {
  id: number = 0;
  airplanes: IAirplane[];
  public displayedColumns: string[] = ['id', 'model', 'passengers', 'creationdate', 'details', 'delete']
  isWaiting: Boolean = false;

  constructor(private service: AirplaneService, private router: Router) { }

  ngOnInit() {
    this.isWaiting = true;
    this.service.getAirplanes().subscribe(airplanes => {
      this.airplanes = airplanes;
      this.isWaiting = false;
    })
  }

  addNew() {
    this.router.navigate(['airplane']);
  }

  delete(id: number) {
    this.isWaiting = true;
    this.service.deleteAirplane(id).subscribe(airplane => {
      this.isWaiting = false;
    });

    setTimeout(() =>
    { this.ngOnInit(); }, 1500)
  }
}
