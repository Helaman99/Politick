/// <reference types="vite/client" />
declare const process: {
    env: {
      VUE_APP_BASE_URL: string;
      VUE_APP_PAYPAL_CLIENT_ID: string;
      // add other environment variables here
    }
  } & typeof globalThis.process;