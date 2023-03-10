export default interface Liquidity {
  id: string;
  number: string;
  balance: number;
  bankCode: string | null;
  alias: string;
  group: string;
  //lastTransactionDate: string;
}
