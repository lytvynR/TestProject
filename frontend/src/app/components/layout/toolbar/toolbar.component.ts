import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'pm-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  @Output() menuClicked = new EventEmitter();

  ngOnInit() {}

  toggleSidenav() {
    this.menuClicked.emit();
  }

}
