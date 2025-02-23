import { NgModule } from '@angular/core';

import { SubjectDetailRoutingModule } from './subject-detail-routing.module';
import { SubjectDetailComponent } from './subject-detail.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SubjectFormModalModule } from '../modal/subject-form-modal.module';
import { VariantsListModule } from '../../variants/list/variants-list.module';
import { VariantsTextListModule } from 'src/app/variants/text-list/text-list.module';
import { VariantsAudioListModule } from '../../variants/audio-list/audio-list.module';
import { VariantsImageListModule } from '../../variants/image-list/image-list.module';
import { SubjectRegenerateButtonComponent } from './regenerate-button/regenerate-button.component';

@NgModule({
  declarations: [SubjectDetailComponent, SubjectRegenerateButtonComponent],
  imports: [
    SharedModule,
    SubjectDetailRoutingModule,
    SubjectFormModalModule,
    VariantsListModule,
    VariantsTextListModule,
    VariantsAudioListModule,
    VariantsImageListModule,
  ],
})
export class SubjectDetailModule {}
