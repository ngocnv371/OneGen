import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { VariantDto, VariantQueryDto } from '../generation/models';

@Injectable({
  providedIn: 'root',
})
export class VariantsService {
  apiName = 'Default';
  

  create = (input: VariantDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VariantDto>({
      method: 'POST',
      url: '/api/app/variants',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/variants/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VariantDto>({
      method: 'GET',
      url: `/api/app/variants/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: VariantQueryDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<VariantDto>>({
      method: 'GET',
      url: '/api/app/variants',
      params: { subjectId: input.subjectId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: VariantDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VariantDto>({
      method: 'PUT',
      url: `/api/app/variants/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
