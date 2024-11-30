import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Component, Input, EventEmitter, Output, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SubjectsService } from '@proxy';
import { SubjectDto } from '@proxy/generation';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'app-subject-form-modal',
  templateUrl: './subject-form-modal.component.html',
})
export class SubjectFormModalComponent {
  @Output()
  saved = new EventEmitter();

  selectedItem = {} as SubjectDto;

  isModalOpen = false;
  isSaving = false;

  form: FormGroup;

  constructor(private service: SubjectsService, private fb: FormBuilder) {}

  create() {
    this.selectedItem = {} as SubjectDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  edit(id: string) {
    this.service.get(id).subscribe(req => {
      this.selectedItem = req;
      this.buildForm();
      this.form.patchValue(req);
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.isSaving = false;
    this.form = this.fb.group({
      operation: [''],
      prompt: ['', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      console.debug('validation', this.form.errors);
      return;
    }

    this.isSaving = true;
    const req = this.selectedItem.id
      ? this.service.update(this.selectedItem.id, this.form.value)
      : this.service.create(this.form.value);

    req
      .pipe(
        catchError(error => {
          this.isSaving = false;
          return throwError(() => error);
        })
      )
      .subscribe(data => {
        this.isModalOpen = false;
        this.form.reset();
        this.saved.emit(data);
      });
  }
}
