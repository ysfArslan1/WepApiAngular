import { Routes } from '@angular/router';
import { BookListComponent } from './features/books/book-list/book-list.component';
import { AddBookComponent } from './features/books/add-book/add-book.component';

export const routes: Routes = [
    {
        path:'',
        component:BookListComponent
    },
    {
        path:'books',
        component:BookListComponent
    },
    {
        path:'books/add',
        component:AddBookComponent
    }
];
