import { NgModule } from '@angular/core';

import { SubjectsListRoutingModule } from './subjects-list-routing.module';
import { SubjectsListComponent } from './subjects-list.component';
import { SharedModule } from '../../shared/shared.module';
import { SubjectFormModalModule } from '../modal/subject-form-modal.module';

@NgModule({
  declarations: [SubjectsListComponent],
  imports: [SharedModule, SubjectsListRoutingModule, SubjectFormModalModule],
})
export class SubjectsListModule {}
