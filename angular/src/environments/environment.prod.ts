import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44383/',
  redirectUri: baseUrl,
  clientId: 'OneGen_App',
  responseType: 'code',
  scope: 'offline_access OneGen',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'OneGen',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44383',
      rootNamespace: 'OneGen',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
