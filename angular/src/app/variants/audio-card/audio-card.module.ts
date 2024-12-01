import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared/shared.module';
import { VariantAudioCardComponent } from './audio-card.component';

@NgModule({
  declarations: [VariantAudioCardComponent],
  imports: [SharedModule],
  exports: [VariantAudioCardComponent],
})
export class VariantAudioCardModule {}
