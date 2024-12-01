import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { VariantDto } from '@proxy/generation';
import { VariantsService } from '@proxy/variants';

@Component({
  selector: 'app-variants-audio-list',
  templateUrl: './audio-list.component.html',
  providers: [ListService],
})
export class VariantsAudioListComponent implements OnInit {
  page = { items: [], totalCount: 0 } as PagedResultDto<VariantDto>;

  @Input({ required: true })
  subjectId!: string;

  constructor(
    public readonly list: ListService,
    private service: VariantsService,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit() {
    const streamCreator = query => this.service.getList({ subjectId: this.subjectId, ...query });

    this.list.hookToQuery(streamCreator).subscribe(response => {
      this.page = response;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.service.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  trackById(item: VariantDto) {
    return item.id;
  }
}
