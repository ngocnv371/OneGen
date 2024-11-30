import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Component, OnInit, ViewChild } from '@angular/core';
import { SubjectFormModalComponent } from '../modal/subject-form-modal.component';
import { SubjectDto } from '@proxy/generation';
import { SubjectsService } from '@proxy';

@Component({
  selector: 'app-subjects-list',
  templateUrl: './subjects-list.component.html',
  providers: [ListService],
})
export class SubjectsListComponent implements OnInit {
  @ViewChild(SubjectFormModalComponent)
  formModal!: SubjectFormModalComponent;

  page = { items: [], totalCount: 0 } as PagedResultDto<SubjectDto>;

  constructor(
    public readonly list: ListService,
    private service: SubjectsService,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit() {
    const streamCreator = query => this.service.getList(query);

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

  onSaved() {
    this.list.get();
  }
}
