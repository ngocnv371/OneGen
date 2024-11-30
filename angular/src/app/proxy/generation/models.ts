import type { SubjectType } from './subject-type.enum';
import type { CreationAuditedEntityDto } from '@abp/ng.core';
import type { GenerationStatus } from './generation-status.enum';

export interface CreateSubjectDto {
  type: SubjectType;
  objectType?: string;
  objectId?: string;
  operation?: string;
  prompt?: string;
}

export interface SubjectDto extends CreationAuditedEntityDto<string> {
  tenantId?: string;
  type: SubjectType;
  status: GenerationStatus;
  objectType?: string;
  objectId?: string;
  operation?: string;
  prompt?: string;
}
