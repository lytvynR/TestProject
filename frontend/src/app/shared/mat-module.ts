import { NgModule } from "@angular/core";
import { MatSidenavModule, MatIconModule, MatButtonModule, MatToolbarModule, MatCardModule, MatSelectModule, MatFormFieldModule,
   MatInputModule, MatDatepickerModule, MatNativeDateModule } from "@angular/material";

@NgModule({
  imports: [
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  exports: [
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ]
})
export class MatModule {}
