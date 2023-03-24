export default interface Liquidity {
  id: string;
  number: string;
  balance: number;
  bankCode: string | null;
  network: string;
  alias: string;
  group: string;
  //lastTransactionDate: string;
}