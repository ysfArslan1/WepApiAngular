import { mergeApplicationConfig, ApplicationConfig } from '@angular/core';
import { provideServerRendering } from '@angular/platform-server';
import { appConfig } from './app.config';
import { BooksService } from './features/books/services/books.service';

const serverConfig: ApplicationConfig = {
  providers: [
    provideServerRendering(),
    BooksService,
  ]
};

export const config = mergeApplicationConfig(appConfig, serverConfig);
