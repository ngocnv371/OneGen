import { NgModule } from '@angular/core';

import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { SubjectFormModalComponent } from './subject-form-modal.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [SubjectFormModalComponent],
  imports: [SharedModule, NgbDatepickerModule],
  exports: [SubjectFormModalComponent],
})
export class SubjectFormModalModule {}
