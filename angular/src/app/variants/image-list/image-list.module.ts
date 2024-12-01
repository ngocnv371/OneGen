import { NgModule } from '@angular/core';

import { VariantsImageListComponent } from './image-list.component';
import { SharedModule } from '../../shared/shared.module';
import { VariantImageCardModule } from '../image-card/image-card.module';

@NgModule({
  declarations: [VariantsImageListComponent],
  imports: [SharedModule, VariantImageCardModule],
  exports: [VariantsImageListComponent],
})
export class VariantsImageListModule {}
