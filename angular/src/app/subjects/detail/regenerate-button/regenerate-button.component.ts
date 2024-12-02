import { Component, Input } from '@angular/core';
import { SubjectsService } from '@proxy/subjects';
import { delay } from 'rxjs';

@Component({
  selector: 'app-subject-regenerate-button',
  templateUrl: './regenerate-button.component.html',
})
export class SubjectRegenerateButtonComponent {
  @Input({ required: true })
  subjectId!: string;

  loading = false;

  constructor(private service: SubjectsService) {}

  handleClick() {
    if (this.loading) {
      return;
    }

    this.loading = true;
    this.service
      .regenerate(this.subjectId)
      .pipe(delay(10_000))
      .subscribe({
        next() {
          console.debug('regeneration requested');
        },
        complete() {
          this.loading = false;
        },
      });
  }
}
