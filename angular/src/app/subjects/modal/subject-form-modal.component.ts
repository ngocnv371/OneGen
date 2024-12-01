import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Component, Input, EventEmitter, Output, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SubjectsService } from '@proxy';
import { SubjectDto, SubjectType, subjectTypeOptions } from '@proxy/generation';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'app-subject-form-modal',
  templateUrl: './subject-form-modal.component.html',
})
export class SubjectFormModalComponent {
  @Output()
  saved = new EventEmitter();

  selectedItem = {} as SubjectDto;

  subjectTypeOptions = subjectTypeOptions;
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
      objectType: 'test',
      objectId: 'ec30009f-a768-43c1-922a-cc1527dd9549',
      operation: ['test'],
      type: [SubjectType.Text],
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
