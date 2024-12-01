import { NgModule } from '@angular/core';

import { VariantsTextListComponent } from './text-list.component';
import { SharedModule } from '../../shared/shared.module';
import { VariantTextCardModule } from '../text-card/variant-text-card.module';

@NgModule({
  declarations: [VariantsTextListComponent],
  imports: [SharedModule, VariantTextCardModule],
  exports: [VariantsTextListComponent],
})
export class VariantsTextListModule {}
