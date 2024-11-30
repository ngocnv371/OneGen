import { mapEnumToOptions } from '@abp/ng.core';

export enum SubjectType {
  Text = 0,
  Image = 1,
  Audio = 2,
}

export const subjectTypeOptions = mapEnumToOptions(SubjectType);
