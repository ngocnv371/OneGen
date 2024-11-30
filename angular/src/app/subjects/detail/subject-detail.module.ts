import { NgModule } from '@angular/core';

import { SubjectDetailRoutingModule } from './subject-detail-routing.module';
import { SubjectDetailComponent } from './subject-detail.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SubjectFormModalModule } from '../modal/subject-form-modal.module';

@NgModule({
  declarations: [SubjectDetailComponent],
  imports: [SharedModule, SubjectDetailRoutingModule, SubjectFormModalModule],
})
export class SubjectDetailModule {}
