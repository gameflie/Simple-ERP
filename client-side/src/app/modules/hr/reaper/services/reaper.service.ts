import { Injectable } from '@angular/core';
import { BaseEntityService } from 'src/app/shared/services/base-entity.service';

@Injectable()
export class ReaperService extends BaseEntityService {
  entityName = "Reaper";
}