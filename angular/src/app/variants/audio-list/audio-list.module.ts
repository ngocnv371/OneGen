import { NgModule } from '@angular/core';

import { VariantsAudioListComponent } from './audio-list.component';
import { SharedModule } from '../../shared/shared.module';
import { VariantAudioCardModule } from '../audio-card/audio-card.module';

@NgModule({
  declarations: [VariantsAudioListComponent],
  imports: [SharedModule, VariantAudioCardModule],
  exports: [VariantsAudioListComponent],
})
export class VariantsAudioListModule {}
