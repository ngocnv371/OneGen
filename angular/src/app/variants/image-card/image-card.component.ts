import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { VariantDto } from '@proxy/generation';
import { VariantsService } from '@proxy/variants';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-variant-image-card',
  templateUrl: './image-card.component.html',
})
export class VariantImageCardComponent {
  apiUrl = environment.apis.default.url;

  @Input({ required: true })
  variant!: VariantDto;
}
