import { mapEnumToOptions } from '@abp/ng.core';

export enum GenerationStatus {
  Pending = 0,
  Processing = 1,
  Completed = 2,
  Failed = 3,
}

export const generationStatusOptions = mapEnumToOptions(GenerationStatus);
