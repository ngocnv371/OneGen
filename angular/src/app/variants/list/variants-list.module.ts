import { NgModule } from '@angular/core';

import { VariantsListComponent } from './variants-list.component';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [VariantsListComponent],
  imports: [SharedModule],
  exports: [VariantsListComponent],
})
export class VariantsListModule {}
