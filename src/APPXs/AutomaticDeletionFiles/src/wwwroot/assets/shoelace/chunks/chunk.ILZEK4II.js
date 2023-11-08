import {
  divider_styles_default
} from "./chunk.NCZWQBRI.js";
import {
  watch
} from "./chunk.Q6ASPMKT.js";
import {
  ShoelaceElement
} from "./chunk.JS655M6J.js";
import {
  __decorateClass
} from "./chunk.MAD5PUM2.js";

// src/components/divider/divider.component.ts
import { property } from "lit/decorators.js";
var SlDivider = class extends ShoelaceElement {
  constructor() {
    super(...arguments);
    this.vertical = false;
  }
  connectedCallback() {
    super.connectedCallback();
    this.setAttribute("role", "separator");
  }
  handleVerticalChange() {
    this.setAttribute("aria-orientation", this.vertical ? "vertical" : "horizontal");
  }
};
SlDivider.styles = divider_styles_default;
__decorateClass([
  property({ type: Boolean, reflect: true })
], SlDivider.prototype, "vertical", 2);
__decorateClass([
  watch("vertical")
], SlDivider.prototype, "handleVerticalChange", 1);

export {
  SlDivider
};
