import { Component, OnInit } from '@angular/core';
import { IAirplane} from '../../models/airplane.model';
import { AirplaneService } from '../airplane.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-airplane-detail',
  templateUrl: './airplane-detail.component.html',
  styleUrls: ['./airplane-detail.component.css']
})
export class AirplaneDetailComponent implements OnInit {
  airplane: IAirplane;
  id: number = 0;
  formGroup: FormGroup;
  isWaiting: Boolean = false;

  constructor(private service: AirplaneService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    public snackBar: MatSnackBar,
    private router: Router) {

    this.formGroup = this.fb.group({       model: ['', Validators.required],       passengers: ['', Validators.required],       creationDate: ['', Validators.required]     }); 
  }

  ngOnInit() {

    this.route.params.subscribe(params => {
      this.id = +params['id'];
      if (!this.id) {
        return;
      }
      this.getAirplane(this.id);
    });
  }

  getAirplane(id: number) {
    this.service.getAirplane(id).subscribe(airplane => {
      this.airplane = airplane;
      this.formGroup.patchValue(this.airplane);
    })
  }

  onSubmit(formValue) {
    this.airplane = formValue;

    if (!this.id) {
      this.service.createAirplane(this.airplane).subscribe(airplane => {
        this.airplane = airplane;
        this.router.navigate(['airplanes']);
      })
    } else {
      this.service.updateAirplane(this.id, this.airplane).subscribe(airplane => {
        console.log("Updated " + this.id);
        this.airplane = airplane;
        this.openSnackBar("Saved", "Success");
      });
    }
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
    });
  }
}
