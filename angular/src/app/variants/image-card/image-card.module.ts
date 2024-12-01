import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared/shared.module';
import { VariantImageCardComponent } from './image-card.component';

@NgModule({
  declarations: [VariantImageCardComponent],
  imports: [SharedModule],
  exports: [VariantImageCardComponent],
})
export class VariantImageCardModule {}
