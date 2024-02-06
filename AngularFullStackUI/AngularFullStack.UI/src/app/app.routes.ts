import { Routes } from '@angular/router';
import { BookListComponent } from './features/books/book-list/book-list.component';
import { AddBookComponent } from './features/books/add-book/add-book.component';
import { UpdateBookComponent } from './features/books/update-book/update-book.component';
import { BookDetailComponent } from './features/books/book-detail/book-detail.component';
import { GenreListComponent } from './features/genres/genre-list/genre-list.component';

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
    },
    {
        path:'books/update/:id',
        component:UpdateBookComponent
    },
    {
        path:'books/detail/:id',
        component:BookDetailComponent
    },
    {
        path:'genres',
        component:GenreListComponent
    }
];
