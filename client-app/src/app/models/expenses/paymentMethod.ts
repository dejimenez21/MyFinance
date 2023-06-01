export const paymentMethods = {
    CREDIT_CARD: {value: "CREDIT_CARD", text: "Credit Card"},
    BANK_ACCOUNT: {value: "BANK_ACCOUNT", text: "Bank Account"},
    CASH: {value: "CASH", text: "Cash"}
}

export interface PaymentMethod {
    text: string,
    value: string
}
