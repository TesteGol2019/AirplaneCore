"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var home_component_1 = require("./home/home.component");
var airplane_component_1 = require("./airplane/airplane.component");
var airplane_detail_component_1 = require("./airplane/airplane-detail/airplane-detail.component");
exports.routes = [
    { path: '', component: home_component_1.HomeComponent, pathMatch: 'full' },
    { path: 'airplanes', component: airplane_component_1.AirplaneComponent },
    { path: 'airplanes/:id', component: airplane_detail_component_1.AirplaneDetailComponent },
    { path: 'airplane', component: airplane_detail_component_1.AirplaneDetailComponent }
];
exports.routing = router_1.RouterModule.forRoot(exports.routes);
//# sourceMappingURL=app.routes.js.map