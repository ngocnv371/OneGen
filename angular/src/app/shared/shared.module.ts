import { CoreModule } from '@abp/ng.core';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { DetailLayoutComponent } from './detail-layout/detail-layout.component';
import { GenerationStatusBadgeComponent } from './generation-status-badge/generation-status-badge.component';

@NgModule({
  declarations: [DetailLayoutComponent, GenerationStatusBadgeComponent],
  imports: [CoreModule, ThemeSharedModule, NgbDropdownModule, NgxValidateCoreModule],
  exports: [
    CoreModule,
    ThemeSharedModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    DetailLayoutComponent,
    GenerationStatusBadgeComponent,
  ],
  providers: [],
})
export class SharedModule {}
