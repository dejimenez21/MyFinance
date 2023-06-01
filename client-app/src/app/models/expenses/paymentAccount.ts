import { PaymentMethod } from "./paymentMethod";

export default interface PaymentAccount {
    id: string;
    name: string;
    method: string,
    number: string;
    currencies: string[];
    bank: string | null;
    network: string | null;
}