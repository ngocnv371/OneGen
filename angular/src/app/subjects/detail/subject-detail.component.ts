import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SubjectsService } from '@proxy/subjects.service';
import { Observable, catchError, throwError } from 'rxjs';
import { SubjectDto, SubjectType } from '@proxy/generation';
import { SubjectFormModalComponent } from '../modal/subject-form-modal.component';

@Component({
  selector: 'app-subject-detail',
  templateUrl: './subject-detail.component.html',
})
export class SubjectDetailComponent implements OnInit {
  @ViewChild(SubjectFormModalComponent)
  formModal!: SubjectFormModalComponent;

  subjectId: string;
  item = {} as SubjectDto;
  isLoading = false;
  SubjectType = SubjectType;

  constructor(route: ActivatedRoute, private service: SubjectsService) {
    this.subjectId = route.snapshot.params.subjectId;
  }

  ngOnInit() {
    this.reload();
  }

  reload(): void {
    this.isLoading = true;
    this.service
      .get(this.subjectId)
      .pipe(
        catchError(error => {
          this.isLoading = false;
          return throwError(() => error);
        })
      )
      .subscribe(v => {
        this.item = v;
        this.isLoading = false;
      });
  }

  onSaved() {
    this.reload();
  }
}
