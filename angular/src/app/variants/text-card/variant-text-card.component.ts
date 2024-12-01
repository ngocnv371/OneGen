import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { VariantDto } from '@proxy/generation';
import { VariantsService } from '@proxy/variants';

@Component({
  selector: 'app-variant-text-card',
  templateUrl: './variant-text-card.component.html',
})
export class VariantTextCardComponent {
  @Input({ required: true })
  variant!: VariantDto;
}
