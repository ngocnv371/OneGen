import { Component, Input } from '@angular/core';
import { GenerationStatus, generationStatusOptions } from '@proxy/generation';

const styles: { [key: number]: string } = {
  [GenerationStatus.Pending]: 'text-bg-secondary',
  [GenerationStatus.Processing]: 'text-bg-primary',
  [GenerationStatus.Completed]: 'text-bg-success',
  [GenerationStatus.Failed]: 'text-bg-danger',
};

@Component({
  selector: 'app-generation-status-badge',
  templateUrl: './generation-status-badge.component.html',
})
export class GenerationStatusBadgeComponent {
  @Input({ required: true })
  status!: GenerationStatus;

  options = generationStatusOptions;

  get style() {
    return styles[this.status];
  }
}
