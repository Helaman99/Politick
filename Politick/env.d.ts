/// <reference types="vite/client" />
declare const process: {
    env: {
      VUE_APP_BASE_URL: string;
      // add other environment variables here
    }
  } & typeof globalThis.process;