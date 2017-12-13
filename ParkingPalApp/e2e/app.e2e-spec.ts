import { ParkingpalAppPage } from './app.po';

describe('parkingpal-app App', () => {
  let page: ParkingpalAppPage;

  beforeEach(() => {
    page = new ParkingpalAppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
