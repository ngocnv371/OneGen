import { NgModule } from '@angular/core';

import { VariantsListComponent } from './variants-list.component';
import { SharedModule } from '../../shared/shared.module';
import { VariantTextCardModule } from '../text-card/variant-text-card.module';

@NgModule({
  declarations: [VariantsListComponent],
  imports: [SharedModule, VariantTextCardModule],
  exports: [VariantsListComponent],
})
export class VariantsListModule {}
