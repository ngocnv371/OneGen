import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared/shared.module';
import { VariantTextCardComponent } from './variant-text-card.component';

@NgModule({
  declarations: [VariantTextCardComponent],
  imports: [SharedModule],
  exports: [VariantTextCardComponent],
})
export class VariantTextCardModule {}
