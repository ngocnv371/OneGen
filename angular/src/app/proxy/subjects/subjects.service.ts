import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateSubjectDto, SubjectDto } from '../generation/models';

@Injectable({
  providedIn: 'root',
})
export class SubjectsService {
  apiName = 'Default';
  

  create = (input: CreateSubjectDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SubjectDto>({
      method: 'POST',
      url: '/api/app/subjects',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/subjects/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SubjectDto>({
      method: 'GET',
      url: `/api/app/subjects/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<SubjectDto>>({
      method: 'GET',
      url: '/api/app/subjects',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  regenerate = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/subjects/${id}/regenerate`,
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateSubjectDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SubjectDto>({
      method: 'PUT',
      url: `/api/app/subjects/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
